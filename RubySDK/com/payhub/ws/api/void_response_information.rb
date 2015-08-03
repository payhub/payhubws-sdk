class VoidResponseInformation
  include JsonSerializer
  ATTRS = [:transaction_id,:lastVoidResponse,:merchantOrganizationId,:_links,:errors,:metaData]
  attr_accessor *ATTRS

  attr_reader :merchantInformation

  attr_writer :transactionManager

  def initialize

  end
end