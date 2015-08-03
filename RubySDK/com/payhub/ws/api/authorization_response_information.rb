class AuthorizationResponseInformation
  include JsonSerializer
  ATTRS=[:authOnlyResponse,:_links,:errors,:metaData]
  attr_accessor *ATTRS
  attr_reader :billInformation,:cardDataInformation,:customerInformation,:merchantInformation
  attr_writer :transactionManager


  def initialize

  end
end