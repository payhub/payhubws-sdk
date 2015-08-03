class SaleResponseInformation
  include JsonSerializer
  ATTRS = [:saleResponse,:_links,:errors,:metaData]
  attr_accessor *ATTRS
  attr_reader :billInformation,:cardDataInformation,:customerInformation,:merchantInformation
  attr_writer :transactionManager

  def initialize

  end

  def billInformation
    if (@billInformation==nil)
      b=BillInformation.new(@transactionManager)
      b.url =@transactionManager.url+"sale/"
      b.getBillForSaleInformationByTransactionId(@saleResponse.saleId)
      @billInformation=b
    end
    return @billInformation
  end

  def cardDataInformation
    if (@cardDataInformation==nil)
      c=CardDataInformation.new(@transactionManager)
      c.url =@transactionManager.url+"sale/"
      c.getBillForSaleInformationByTransactionId(@saleResponse.saleId)
      @billInformation=b
    end
    return @billInformation
  end
end