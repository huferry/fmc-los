<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Classes extends Model {
    protected $table = "class";
    protected $primaryKey = "class_id";

    public function meetings() {
        return $this->hasMany('App\Meeting', 'cla_class_id')->get();
    }

    private function classRelations() {
        return $this->hasMany('App\ClassRelation', 'cla_class_id')->get();
    }

    public function relations() {
        $result = [];
        foreach($this->classRelations() as $clr) {
            $rel = Relation::find($clr->rel_relation_id);
            $result[] =['relation_id' => $rel->relation_id, 
            'firstname' => $rel->firstname, 'lastname' => $rel->lastname];
        }
        return json_encode($result);
    }
}