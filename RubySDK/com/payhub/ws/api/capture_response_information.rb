class CaptureResponseInformation
  include JsonSerializer
  ATTRS=[:lastCaptureResponse,:_links,:errors,:metaData]
  attr_accessor *ATTRS
  attr_reader :billInformation,:merchantInformation
  attr_writer :transactionManager

  def initialize

  end
end