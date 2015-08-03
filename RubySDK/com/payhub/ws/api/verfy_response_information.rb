class VerfyResponseInformation
  include JsonSerializer
  ATTRS=[:verifyResponse,:_links,:errors,:metaData]
  attr_accessor *ATTRS
  attr_reader :cardDataInformation,:customerInformation,:merchantInformation
  attr_writer :transactionManager

  def initialize

  end
end