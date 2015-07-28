<?php

/**
 * Created by PhpStorm.
 * User: agustin
 * Date: 24/07/2015
 * Time: 11:12
 */
class VoidResponse
{
    public $saleTransactionId;
    public $voidTransactionId;
    public $token;

    public static function fromArray($data){
        if(!is_null($data)) {
            $void = new VoidResponse();

            foreach ($data as $key => $value) {
                if (property_exists(get_class($void), $key)) {
                    $void->{$key} = $value;
                }
            }
            return $void;
        }
    }
}