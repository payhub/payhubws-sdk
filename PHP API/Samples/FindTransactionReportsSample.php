<?php
/**
 * Created by PhpStorm.
 * User: agustin
 * Date: 28/07/2015
 * Time: 16:51
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

$tsr = new TransactionSearchParameters();
$tsr->amountFrom="1";
$tsr->amountTo="20";
$tsr->cardLast4Digits="4507";

$transaction = new TransactionManager($merchant,$WsURL,$oauth_token);
$response = $transaction->findTransactions($tsr);
