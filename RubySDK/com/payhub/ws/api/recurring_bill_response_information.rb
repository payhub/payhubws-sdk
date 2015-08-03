class RecurringBillResponseInformation
  include JsonSerializer
  ATTRS=[:status,:lastRecurringBillResponse,:_links,:errors,:metaData]
  attr_accessor *ATTRS

  attr_reader :billInformation,:cardDataInformation,:customerInformation,:merchantInformation,:scheduleInformation
  attr_writer :transactionManager

  def initialize

  end
end