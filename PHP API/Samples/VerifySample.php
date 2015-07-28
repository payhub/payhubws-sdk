<?php
/**
 * Created by PhpStorm.
 * User: agustin
 * Date: 28/07/2015
 * Time: 12:05
 */
include_once '../com/payhub/ws/extra/includeClasses.php';
//Defining the Web Service URL
$WsURL="https://staging-api.payhub.com/api/v2/";
$oauth_token = "107d74ab-4a18-4713-88ff-69bd05710086";

//Defining data for the SALE transaction
// Merchant data (obtained from the payHub Virtual Terminal (3rd party integration)
$merchant = new Merchant();
$merchant->setOrganizationId(10127);
$merchant->setTerminalId(215);

//Credit card data
$card_data = new CardData();
$card_data->setCardNumber("5466410004374507");
$card_data->setCardExpiryDate("202011");
$card_data->setCvvData("998");
$card_data->setBillingAddress1("2350 Kerner Blvd");
$card_data->setBillingAddress2("On the corner");
$card_data->setBillingCity("San Rafael");
$card_data->setBillingState("CA");
$card_data->setBillingZip("99997-0003");
// Customer data
$customer = new Customer();
$customer->setFirstName("First");
$customer->setLastName("Contact");
$customer->setCompanyName("Payhub Inc");
$customer->setJobTitle("Software Engineer");
$customer->setEmailAddress("jhon@company.com");
$customer->setWebAddress("http://payhub.com");
$customer->setPhoneNumber("(415) 479 1349");
$customer->setPhoneExt("123");
$customer->setPhoneType("M");


$object = new Verify($merchant,$customer,$card_data);

$transaction = new TransactionManager($merchant,$WsURL,$oauth_token);
//$result = $transaction->doVerify($object);
//var_dump($result);
//$transactionId = $result->getVerifyResponse()->getVerifyId();
//$result2 = $transaction->getVerifyInformation($transactionId);
//var_dump($result2);
$result3=$transaction->getAllVerifyInformation();
var_dump($result3);