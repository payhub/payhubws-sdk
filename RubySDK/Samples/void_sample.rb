require 'PayHubSDK/com/payhub/ws/extra/include_classes'

wsURL="https://staging-api.payhub.com/api/v2/"
oauth_token = "107d74ab-4a18-4713-88ff-69bd05710086"

merchant = Merchant.new
merchant.organization_id=10127
merchant.terminal_id=215

transaction_id="182937"

object = VoidTransaction.new(merchant, transaction_id)

transaction = TransactionManager.new(wsURL,oauth_token,merchant)
#response = transaction.doSale(object)
#puts transaction.getSaleInformation("182786")
#response = transaction.doVoid(object)
response = transaction.getVoidInformation("181258")
puts response.merchantInformation.inspect