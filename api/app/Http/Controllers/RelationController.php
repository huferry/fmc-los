<?php

namespace App\Http\Controllers;

use App;
use Illuminate\Http\Request;

class RelationController extends Controller
{
    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($id)
    {
        $rel = App\Relation::find($id);
        return json_encode($rel);
    }

    public function showByName($name)
    {
        $rels = App\Relation::whereRaw("firstname like '%$name%' or lastname like '%$name%'")->get();
        return $rels->toJson();
    }
}
