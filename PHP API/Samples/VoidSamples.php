<?php
/**
 * Created by PhpStorm.
 * User: agustin
 * Date: 28/07/2015
 * Time: 12:56
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

$void = new VoidTransaction($merchant,'{someSaleId}');
$transaction = new TransactionManager($merchant,$WsURL,$oauth_token);
$result=$transaction->getVoidInformation("182378");
var_dump($result);
$result2=$transaction->getAllVoidInformation();
var_dump($result2);
