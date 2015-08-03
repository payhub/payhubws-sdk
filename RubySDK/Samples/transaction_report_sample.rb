require '../com/payhub/ws/extra/include_classes'

wsURL="https://staging-api.payhub.com/api/v2/"
oauth_token = "107d74ab-4a18-4713-88ff-69bd05710086"

merchant = Merchant.new
merchant.organization_id=10127
merchant.terminal_id=215

transaction = TransactionManager.new(wsURL,oauth_token,merchant)
parameters="{\"amountFrom\": \"1\",  \"amountTo\":\"1002\",  \"cardLast4Digits\": \"4507\",  \"batchIdFrom\":\"1300\",  \"batchIdTo\":\"1320\",  \"email\":\"marrighi\",  \"transactionType\":\"Sale\",  \"responseCode\":\"00\",  \"firstName\":\"First\",  \"lastName\":\"Cont\",  \"phoneNumber\":\"(415) 479 1349\",  \"trnDateFrom\":\"2015-04-01 00:00:00\",  \"trnDateTo\":\"2015-04-30 00:00:00\",  \"cardType\":\"MasterCard\",  \"cardToken\":\"9999000000001853\",  \"swiped\":\"true\",  \"source\":\"3rd Party API\"}"
puts transaction.findTransactions(parameters)
