<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class ClassRelation extends Model {
    protected $table = "class_relation";
    protected $privateKey =  array('cla_class_id', 'rel_relation_id');
} 