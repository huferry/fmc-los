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
    public function show(Request $request, $id) {
        return App\Relation::where('relation_id', $id)
            ->select($this->getSelection($request))
            ->get();
    }

    public function showByName(Request $request, $name) {
        $rels = App\Relation::
                select($this->getSelection($request))
                ->whereRaw("firstname like '%$name%' or lastname like '%$name%'")
                ->get();
        return $rels->toJson();
    }

    private function getSelection(Request $request) {
        if ($request->input('full') == '1') {
            return '*';
        }
        return array('relation_id', 'firstname', 'lastname');
    }

}
