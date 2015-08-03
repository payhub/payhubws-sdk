class BillInformation
  include JsonSerializer
  ATTRS=[:version,:createdAt,:lastModified,:createdBy,:lastModifiedBy,:metaData]
  attr_accessor :url,:transactionManager,:bill,*ATTRS

  # @param [Object] transactionManager
  def initialize(transactionManager=nil)
    @transactionManager=transactionManager
    @transactionType=TransactionType::Bill
  end

  def convertData(json)
      obj = JSON.parse(json)
      @version=obj['version']
      @createdAt=obj['createdAt']
      @lastModified=obj['lastModified']
      @createdBy=obj['createdBy']
      @lastModifiedBy=obj['lastModifiedBy']
      @metaData=obj['metaData']
  end

  def convertDataToBill(json)
      @bill = Bill.from_json(json)
  end
  private :convertData, :convertDataToBill

  def getBillForSaleInformationByTransactionId(saleId)
    url = @url+saleId+"/bill"
    response = @transactionManager.doGet(url, @transactionManager.token)
    convertData(response)
    convertDataToBill(response)
  end

end