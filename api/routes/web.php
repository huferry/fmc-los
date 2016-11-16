<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/



Route::get('/', function () {
    return view('welcome');
});

Route::get('relation/{id}', 'RelationController@show');
Route::get('relation/name/{name}', 'RelationController@showByName');
Route::get('class/year/{year}', 'ClassesController@showByYear');
Route::get('class/{class_id}/relation', 'ClassesController@showRelation');
Route::get('class/{id}', 'ClassesController@show');
Route::get('class/{class_id}/meeting', 'ClassesController@showMeeting');
