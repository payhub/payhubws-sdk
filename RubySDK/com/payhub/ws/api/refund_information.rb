class RefundInformation
  include JsonSerializer
  ATTRS=[:transaction_id,:lastRefundResponse,:_links,:errors,:metaData]
  attr_accessor *ATTRS

  attr_reader :merchantInformation

  attr_writer :transactionManager

  def initialize

  end
end