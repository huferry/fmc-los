<?php

namespace App\Http\Controllers;

use App;
use Illuminate\Http\Request;

class ClassesController extends Controller
{
    public function show($id) {
        $cla = App\Classes::find($id);
        return $cla;
    }

    public function showByYear($year) {
        $cla = App\Classes::whereRaw("date_begin >= '$year-01-01'")->get();
        return $cla;
    }

    public function showMeeting($class_id) {
        $class = App\Classes::find($class_id);
        return $class->meetings();
    }

    public function showRelation($class_id) {
        return App\Classes::find($class_id)->relations();
    }
}
