require 'json'
module JsonSerializer
  def serialize_to_json
    h = {}
    self.class::ATTRS.each do |x|
      val = instance_variable_get "@#{x}"
      next if val.nil?

      str = x.to_s[0].upcase + x.to_s[1..-1]
      str = "CardData" if str == "Card_data"
      str = "TransactionAmount" if str == "Base_amount" or  str == "Tax_amount" or  str == "Shipping_amount" or  str == "TotalAmount"
      str = "ScheduleStartAndEnd" if str == "Schedule_start_and_end"
      str = "MonthlySchedule" if str == "Monthly_schedule"
      h[x] = Kernel.const_defined?(str) ? val.serialize_to_json : val
    end
      jsonObject = JSON.generate(h)
      string = jsonObject.gsub('\\','').gsub('"{','{').gsub('}"','}')
      return string
  end

  def self.included(o)
    o.extend(ClassMethods)
  end

  module ClassMethods
    def from_json(data)
      obj = self.allocate
      data = JSON.parse(data)
      data.each do |k,v|
        next if v==nil
            next if not self::ATTRS.include?(k.to_sym)
            k = "voidResponse" if k == "lastVoidResponse"
            k = "recurringBillResponse" if k == "lastRecurringBillResponse"
            k = "captureResponse" if k=="lastCaptureResponse"
            str = k[0].upcase + k[1..-1]
            defined = Kernel.const_defined?(str) rescue false
            if defined
              k = "lastVoidResponse" if k == "voidResponse"
              k = "lastRecurringBillResponse" if k == "recurringBillResponse"
              k = "lastCaptureResponse" if k=="captureResponse"
              if k=="transactionType"
                obj.instance_variable_set "@#{k}",v
              else
                if k=="status" and obj.is_a?(Errors)
                  obj.instance_variable_set "@#{k}",v
                else
                    obj.instance_variable_set "@#{k}", Kernel.const_get(str).from_json(JSON.generate(v))
                end

              end
            else
              obj.instance_variable_set "@#{k}", v
            end
      end
      obj
    end
  end
end