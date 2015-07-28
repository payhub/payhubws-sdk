<?php

/**
 * Created by PhpStorm.
 * User: agustin
 * Date: 24/07/2015
 * Time: 11:23
 */
class Schedule
{
    public $schedule_type;
    public $bill_generation_interval;
    public $schedule_start_and_end;
    public $monthly_schedule;

    /**
     * Schedule constructor.
     * @param $schedule_start_and_end
     * @param $monthly_schedule
     */
    public function __construct(ScheduleSartAndEnd $schedule_start_and_end, MontlySchedule $monthly_schedule)
    {
        $this->schedule_start_and_end = $schedule_start_and_end;
        $this->monthly_schedule = $monthly_schedule;
    }


}