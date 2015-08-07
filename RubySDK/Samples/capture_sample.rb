require 'PayHubSDK/com/payhub/ws/extra/include_classes'

wsURL="https://staging-api.payhub.com/api/v2/"
oauth_token = "107d74ab-4a18-4713-88ff-69bd05710086"

merchant = Merchant.new
merchant.organization_id=10127
merchant.terminal_id=215

=begin
# bill data
bill= Bill.new
bill.base_amount=1.00

#Credit card data
card_data = CardData.new
card_data.card_number="4055011111111111"
card_data.card_expiry_date="202012"
card_data.billing_zip="99997-0003"
# Customer data
customer = Customer.new
customer.first_name="First"
customer.last_name="Contact"
customer.phone_number="844-217-1631"
customer.phone_type="W"

montly_s=MonthlySchedule.new("E",15)
puts montly_s.inspect
start=Date.new(2015,8,29)
type="O"
endDate=Date.new(2016,8,29)
scheduleSandE=ScheduleStartAndEnd.new(start,type,endDate)
schedule = Schedule.new(scheduleSandE,montly_s)
schedule.schedule_type="M"
schedule.bill_generation_interval=1
object = RecurringBill.new(merchant, customer, bill, card_data, schedule)
=end
transaction = TransactionManager.new(wsURL,oauth_token,merchant)
response = transaction.getCaptureInformation("182357")
puts response.inspect