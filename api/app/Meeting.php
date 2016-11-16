<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Meeting extends Model {

    protected $table = "meeting";
    protected $primaryKey = "meeting_id";

    public function classes() {
        return $this->belongsTo('Classes', 'cla_class_id');
    }


}
