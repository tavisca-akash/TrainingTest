var wHtml = "";

//---Tabs----
wHtml += ('<Div id="tab-bars">');
wHtml += ('<ul class="nav nav-tabs">');
wHtml += ('<li class="active"><a href="#sensex">sensex</a></li>');
wHtml += ('<li><a  href="#nifty">nifty</a></li>');
wHtml += ('<li><a href="#cac">cac</a></li>');
wHtml += ('<li ><a href="#dowjones">dowjones</a></li>');
wHtml += ('<li><a href="#ftse">ftse</a></li>');
wHtml += ('<li><a href="#nasdaq">nasdaq</a></li>');
wHtml += ('<li><a href="#nikkie225">nikkie225</a></li>');
wHtml += ('</ul>');
wHtml += ('</Div>');
wHtml += ('&nbsp');
wHtml += ('&nbsp');

//---SENSEX result
wHtml += ('<Div id="result">');
wHtml += ('<Div id="exchangeLabel">');
wHtml += ('	<label>SENSEX</label>');
wHtml += ('</Div>');
wHtml += ('<Div id="exchangeResult">');
wHtml += ('	<label></label>');
wHtml += ('</Div>');
wHtml += ('&nbsp');
wHtml += ('&nbsp');
wHtml += ('</Div>');
//---Range
wHtml += ('<Div id="range">');
wHtml += ('	<label>Todays HIGH/LOW</label>');
wHtml += ('</Div>');

wHtml += ('<Div id="highLow">');
wHtml += ('	<label></label>');
wHtml += ('</Div>');

wHtml += ('&nbsp');
wHtml += ('&nbsp');

//---graph
wHtml += ('<Div id="graph">');
wHtml += ('	<label>Graph</label>');
wHtml += ('</Div>');
document.write(wHtml);

//---tab clicked
$(document).ready(function () {
    $(".nav-tabs a").click(function () {
        var tabUrl = "" + this;
        var tab = parseTab(tabUrl);
        consumeAPI(tab);
        
    });
});

//--parse tab
var parseTab = function (tabUrl) {
        var tab = tabUrl.split('#');
        return tab[1];
}

//consumeAPI
var consumeAPI = function (tab) {
    $.getJSON("http://training.appyoda.io/api/stock/" + tab, function (result) {
        var j = 0;
        var data=[];
        $.each(result, function (i, field) {
            data[j] = field;
            j++;
        })
        displayResult(data);

    });
}

var displayResult = function (data) {
    var resultLabel = document.getElementById("exchangeResult");
    resultLabel.innerHTML = data[2] + " " + data[3] + '&nbsp' + "  (" + '&nbsp' + data[4] + ")";
    var highlow = document.getElementById("highLow");
    highlow.innerHTML = data[6] + '&nbsp' + data[7];

}