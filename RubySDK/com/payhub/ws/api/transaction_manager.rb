class TransactionManager < WsConnections

  attr_reader :url,:token
  # TransactionManager constructor.
  # @param $_merchant
  # @param $_url
  # @param $_oauthToken
  def initialize(url,token,merchant)
    Util::validate_params(self.class.name, url,token,merchant)
    @url=url
    @token=token
    @merchant=merchant
  end


  #Perform a new Sale.
  #
  #@param sale object.
  #@return a SaleResponseInformation object.
  #@see {@link com.payhub.ws.api.SaleResponseInformation};
  def doSale(sale)
    sale.merchant=@merchant
    sale.url=@url
    sale.token=@token
    http,request = setHeadersPost(sale.url,@token)
    response = sale.doSale(http,request)
    return response
  end

  # Perform a new query that retrieves you the Sale Information for a particular Sale.
  #
  # @param String saleId: the ID of a particular Sale transaction.
  # @return a SaleResponseInformation object.
  # @see {@link com.payhub.ws.api.SaleResponseInformation};
  def getSaleInformation(saleId)
    if saleId.to_s=='' || saleId==nil
      return nil
    end
    url=@url+Sale::SALE_ID_LINK+saleId
    result=JSON.parse(doGet(url,@token))
    response = SaleResponseInformation.new
    if result['error']==nil
      response = SaleResponseInformation.from_json(JSON.generate(result))
      response.transactionManager = self
      return response
    else
      response.errors = Errors.from_json(JSON.generate(result))
      return response
    end
  end
  # Perform a new query that retrieves you the list of Sales Information.
  #
  # @return a SaleResponseInformation list object.
  # @see {@link com.payhub.ws.api.SaleResponseInformation};
  def getAllSalesInformation()
    url=@url+Sale::SALE_ID_LINK
    result=JSON.parse(doGet(url,@token))
    #convertir a array el result
    response ||= Array.new
    if result['error']==nil
      result['_embedded']['sales'].each do |sales|
        response_tmp = SaleResponseInformation.from_json(JSON.generate(sales))#sales #SaleResponseInformation::fromArray(sales)
        response_tmp.transactionManager=self
        response.push(response_tmp)
    end
    else
      response_tmp = Errors.from_json(JSON.generate(result))
      response.push(response_tmp)
    end

    return response;
  end

  # Perform a new Authorization.
  #
  # @param authorization object.
  # @return an AuthorizationResponseInformation object.
  # @see {@link com.payhub.ws.api.AuthorizationResponseInformation};
  def doAuthOnly(auth)
    auth.merchant=@merchant
    auth.url=@url
    auth.token=@token
    http,request = setHeadersPost(auth.url,@token)
    resposne = auth.doAuthOnly(http,request)
    response.transactionManager = self
    return resposne
  end

  # Perform a new query that retrieves you the Authorization Information for a particular Authorization.
  #
  # @param String authorizationId: the ID of a particular AuthorizationOnly transaction.
  # @return an AuthorizationResponseInformation object.
  # @see {@link com.payhub.ws.api.AuthorizationResponseInformation};
  def getAuthorizationInformation(authorizationId)
    if authorizationId.to_s=='' || authorizationId==nil
      return nil
    end
    url=@url+AuthOnly::AUTH_ID_LINK+authorizationId
    result=JSON.parse(doGet(url,@token))
    response = AuthorizationResponseInformation.new
    if result['error']==nil
      response = AuthorizationResponseInformation.from_json(JSON.generate(result))
      response.transactionManager = self
      return response
    else
      response.errors = Errors.from_json(JSON.generate(result))
      return response
    end
  end

  # Perform a new CaptureResponse.
  #
  # @param capture object.
  # @return a LastCaptureResponseInformation object.
  # @see {@link com.payhub.ws.api.CaptureResponseInformation};
  def doCapture(capture)
    capture.merchant=@merchant
    capture.url=@url
    capture.token=@token
    http,request = setHeadersPost(capture.url,@token)
    response = capture.doCapture(http,request)
    response.transactionManager = self
    return response
  end

  # Perform a new query that retrieves you the Capture Information for a particular Capture.
  #
  # @param String captureId: the ID of a particular Capture.
  # @return a LastCaptureResponseInformation object.
  # @see {@link com.payhub.ws.api.CaptureResponseInformation};
  def getCaptureInformation(captureId)
    if captureId.to_s=='' || captureId==nil
      return nil
    end
    url=@url+Capture::CAPTURE_ID_LINK+captureId
    result=JSON.parse(doGet(url,@token))
    response = CaptureResponseInformation.new
    if result['error']==nil
      response = CaptureResponseInformation.from_json(JSON.generate(result))
      response.transactionManager = self
      return response
    else
      response.errors = Errors.from_json(JSON.generate(result))
      return response
    end
  end

  # Perform a new Void Transaction.
  #
  # @param VoidTransaction object.
  # @return a LastVoidResponseInformation object.
  # @see {@link com.payhub.ws.api.VoidResponseInformation};
  def  doVoid(void)
    void.merchant=@merchant
    void.url=@url
    void.token=@token
    http,request = setHeadersPost(void.url,@token)
    response = void.performVoidTransaction(http,request)
    response.transactionManager = self
    return response
  end

  # Perform a new query that retrieves you the Void Information for a particular Void Transaction.
  #
  # @param String voidId: the ID of a particular Void Transaction.
  # @return a LastVoidResponseInformation object.
  # @see {@link com.payhub.ws.api.VoidResponseInformation};
  def getVoidInformation(voidId)
    if voidId.to_s=='' || voidId==nil
      return nil
    end
    url=@url+VoidTransaction::VOID_ID_LINK+voidId
    result=JSON.parse(doGet(url,@token))
    response = VoidResponseInformation.new
    if result['error']==nil
      response = VoidResponseInformation.from_json(JSON.generate(result))
      response.transactionManager = self
      return response
    else
      response.errors = Errors.from_json(JSON.generate(result))
      return response
    end
  end

  # Perform a new Verify.
  #
  # @param Verify object.
  # @return a VerfyResponseInformation object.
  # @see {@link com.payhub.ws.api.VerfyResponseInformation};
  def doVerify(verify)
    verify.merchant=@merchant
    verify.url=@url
    verify.token=@token
    http,request = setHeadersPost(verify.url,@token)
    response = verify.performVerifyTransaction(http,request)
    response.transactionManager = self
    return response
  end

  # Perform a new query that retrieves you the Verify Information for a particular Verify Transaction.
  #
  # @param String verifyId: the ID of a particular Verify Transaction.
  # @return a VerfyResponseInformation object.
  # @see {@link com.payhub.ws.api.VerfyResponseInformation};
  def getVerifyInformation(verifyId)
    if verifyId.to_s=='' || verifyId==nil
      return nil
    end
    url=@url+Verify::VERIFY_ID_LINK+verifyId
    result=JSON.parse(doGet(url,@token))
    response = VerfyResponseInformation.new
    if result['error']==nil
      response = VerfyResponseInformation.from_json(JSON.generate(result))
      response.transactionManager = self
      return response
    else
      response.errors = Errors.from_json(JSON.generate(result))
      return response
    end
  end

  # Perform a new Refund.
  #
  # @param Refund object.
  # @return a RefundInformation object.
  # @see {@link com.payhub.ws.api.RefundInformation};
  def doRefund(refund)
    refund.merchant=@merchant
    refund.url=@url
    refund.token=@token
    http,request = setHeadersPost(refund.url,@token)
    response = refund.performRefund(http,request)
    response.transactionManager = self
    return response
  end

  # Perform a new query that retrieves you the Refund Information for a particular Refund Operation.
  #
  # @param String refundId: the ID of a particular Refund Transaction.
  # @return a RefundInformation object.
  # @see {@link com.payhub.ws.api.RefundInformation};
  def getRefundInformation(refundId)
    if refundId.to_s=='' || refundId==nil
      return nil
    end
    url=@url+Refund::REFUND_ID_LINK+refundId
    result=JSON.parse(doGet(url,@token))
    response = RefundInformation.new
    if result['error']==nil
      response = RefundInformation.from_json(JSON.generate(result))
      response.transactionManager = self
      return response
    else
      response.errors = Errors.from_json(JSON.generate(result))
      return response
    end
  end

  # Perform a new RecurringBilling.
  #
  # @param RecurringBill object.
  # @return a RecurringBillingInformation object.
  # @see {@link com.payhub.ws.api.RecurringBillResponseInformation};
  def doRecurringBill(recurringBill)
    recurringBill.merchant=@merchant
    recurringBill.url=@url
    recurringBill.token=@token
    http,request = setHeadersPost(recurringBill.url,@token)
    response = recurringBill.performRecurringBill(http,request)
    response.transactionManager = self
    return response
  end

  # Perform a new query that retrieves you the Recurring Bill Information for a particular Recurring Bill transaction.
  #
  # @param String recurringBillId: the ID of a particular Recurring Bill Transaction.
  # @return a RecurringBillingInformation object.
  # @see {@link com.payhub.ws.api.RecurringBillResponseInformation};
  def getRecurringBillInformation(recurringBillId)
    if recurringBillId.to_s=='' || recurringBillId==nil
      return nil
    end
    url=@url+RecurringBill::RECURRENT_BILL_ID_LINK+recurringBillId
    result=JSON.parse(doGet(url,@token))
    response = RecurringBillResponseInformation.new
    if result['error']==nil
      response = RecurringBillResponseInformation.from_json(JSON.generate(result))
      response.transactionManager = self
      return response
    else
      response.errors = Errors.from_json(JSON.generate(result))
      return response
    end
  end

  def findTransactions(parameters)
    url=@url+"report/transactionReport/"
    http,request = setHeadersPost(url,@token)
    transactionReports = JSON.parse(findTransactionReports(http,request,parameters));
    response ||= Array.new
    if not transactionReports.include?('errors')
      transactionReports.each do |transactionReport|
        response_aux=TransactionReportInformation.from_json(JSON.generate(transactionReport))
        response.push(response_aux)
      end
    else
      response_tmp = Errors.from_json(JSON.generate(transactionReports['errors']))
      response.push(response_tmp)
    end
    return response
  end

  # @param [Object] datos
  # @param [Object] type
  # @param [Object] operationId
  def addMetaData(datos, type, operationId)
    metadataUrl=nil
    if TransactionType::Sale==type
        metadataUrl=url+"metadata/forSale/"+operationId
    elsif TransactionType::AuthOnly==type
        metadataUrl=url+"metadata/forAuthOnly/"+operationId
    elsif TransactionType::Capture==type
        metadataUrl=url+"metadata/forCapture/"+operationId
    elsif TransactionType::Bill==type
        metadataUrl=url+"metadata/forBill/"+operationId
    elsif TransactionType::CardData==type
        metadataUrl=url+"metadata/forCardData/"+operationId
    elsif TransactionType::Customer==type
        metadataUrl=url+"metadata/forCustomer/"+operationId
    elsif TransactionType::Merchant==type
        metadataUrl=url+"metadata/forMerchant/"+operationId
    elsif TransactionType::RecurringBill==type
        metadataUrl=url+"metadata/forRecurringBill/"+operationId
    elsif TransactionType::Schedule==type
        metadataUrl=url+"metadata/forSchedule/"+operationId
    elsif TransactionType::Refund==type
        metadataUrl=url+"metadata/forRefund/"+operationId
    elsif TransactionType::VoidTransaction==type
        metadataUrl=url+"metadata/forVoid/"+operationId
    end
    http,request = setHeadersPut(metadataUrl,@token)
    request.body=datos
    result=doPut(http,request)
    if result.body.to_s==''
      return true
    else
      return result.body
    end

  end
end