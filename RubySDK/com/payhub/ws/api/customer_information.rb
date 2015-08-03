class CustomerInformation
  include JsonSerializer
  ATTRS=[:version,:createdAt,:lastModified,:createdBy,:lastModifiedBy,:metaData]
  attr_accessor :url,:transactionManager,:customer,*ATTRS
  # @param [Object] transactionManager
  def initialize(transactionManager=nil)
    @transactionManager=transactionManager
    @transactionType=TransactionType::Bill
  end
end