<?php

/**
 * Created by PhpStorm.
 * User: agustin
 * Date: 24/07/2015
 * Time: 09:09
 */
class VerifyResponseInformation
{
    public $verifyResponse;
    public $_links;
    public $errors;
    public $rowData;
    private $transactionManager;
    private $cardDataInformation;
    private $customerInformation;
    private $merchantInformation;

    /**
     * @return mixed
     */
    public function getVerifyResponse()
    {
        return $this->verifyResponse;
    }

    /**
     * @param mixed verifyResponse
     */
    public function setVerifyResponse($verifyResponse)
    {
        $this->verifyResponse = $verifyResponse;
    }

    /**
     * @return mixed
     */
    public function getLinks()
    {
        return $this->_links;
    }

    /**
     * @param mixed $links
     */
    public function setLinks($links)
    {
        $this->_links = $links;
    }

    /**
     * @return mixed
     */
    public function getErrors()
    {
        return $this->errors;
    }

    /**
     * @param mixed $errors
     */
    public function setErrors($errors)
    {
        $this->errors = $errors;
    }

    /**
     * @return mixed
     */
    public function getRowData()
    {
        return $this->rowData;
    }

    /**
     * @param mixed $rowData
     */
    public function setRowData($rowData)
    {
        $this->rowData = $rowData;
    }

    /**
     * @param mixed $transactionManager
     */
    public function setTransactionManager($transactionManager)
    {
        $this->transactionManager = $transactionManager;
    }

    /**
     * @return mixed
     */
    public function getCardDataInformation()
    {
        return $this->cardDataInformation;
    }

    /**
     * @param mixed $cardDataInformation
     */
    public function setCardDataInformation($cardDataInformation)
    {
        $this->cardDataInformation = $cardDataInformation;
    }

    /**
     * @return mixed
     */
    public function getCustomerInformation()
    {
        return $this->customerInformation;
    }

    /**
     * @param mixed $customerInformation
     */
    public function setCustomerInformation($customerInformation)
    {
        $this->customerInformation = $customerInformation;
    }

    /**
     * @return mixed
     */
    public function getMerchantInformation()
    {
        return $this->merchantInformation;
    }

    /**
     * @param mixed $merchantInformation
     */
    public function setMerchantInformation($merchantInformation)
    {
        $this->merchantInformation = $merchantInformation;
    }
    public static function fromArray($data){
        $verif = new VerifyResponseInformation();

        foreach ($data as $key => $value){
            if( property_exists( get_class($verif), $key ) ) {
                if($key=="verifyResponse"){
                    $verif->{$key}=VerifyResponse::fromArray($value);
                }elseif($key=="errors"){
                    $verif->{$key}=Errors::fromArray($value);
                }
                else{
                    $verif->{$key} = $value;
                }
            }
        }
        return $verif;
    }
}