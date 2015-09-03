var wHtml = "";

//---Tabs----
    wHtml+=('<Div id="tab-bars">');
    wHtml+=('<ul class="nav nav-tabs">');
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
    wHtml += ('	<label>SENSEX</label>');
    wHtml += ('</Div>');
    wHtml += ('&nbsp');
    wHtml += ('&nbsp');

//---Range
    wHtml += ('<Div id="range">');
    wHtml += ('	<label>Todays HIGH/LOW</label>');
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
            
        })
    });

    var parseTab = function (tabUrl)
    {
        var tab = tabUrl.split('#');
        return tab[1];
    }
    



