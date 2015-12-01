function Continent(naam, continentCode) {
    this.naam = naam;
    this.continentCode = continentCode;
}

function Land(naam, landCode) {
    this.naam = naam;
    this.landCode = landCode;
}

function Locatie(naam, lengtegraad, breedtegraad) {
    this.naam = naam;
    this.lengtegraad = lengtegraad;
    this.breedtegraad = breedtegraad;
}

function ChooseKlimatogram() {
    this.continenten = [];
    this.landen = [];
    this.locaties = [];
    this.land = "";
    this.continent = "";
    this.chart = new google.visualization.GeoChart(document.getElementById('kaart'));
    this.data = "";
    this.options = "";
}

//Toont de bollen met de mogelijk continenten
ChooseKlimatogram.prototype.showContinenten = function () {
    var self = this;
    //view.drawMap('Region Code', "", geefCorrecteOptions("continents", "world"));

    self.vulData('continent', "", 1);
    self.vulOptions('world', 'continents');
    self.chart.draw(self.data, self.options);

    var content = $(".continentMenu .flex");
    content.html("");
    $.each(this.continenten, function (index, item) {
        var div = $("<div/>");
        div.addClass("continentButton");
        var link = $("<a/>");
        link.attr("id", item.naam);
        link.append(item.naam);
        link.attr("style", "cursor: pointer");
        link.click(function () {
            self.continent = item;
            self.getLanden();
        });
        link.hover(function () {
            //Hover over een continent, naam continent zit in link.attr("id")
            if (item.naam == "Noord-Amerika" || item.naam == "Zuid-Amerika") {
                self.vulOptions('world', 'subcontinents');
            } else {
                self.vulOptions('world', 'continents');
            }
            self.vulData('continent', item.continentCode, 1);
            self.chart.draw(self.data, self.options);
        }, function () {
            //Hover is gedaan
            self.vulData('continent', "", 1);
            self.chart.draw(self.data, self.options);
        });
        div.append(link);
        content.append(div);
    });
    $(".continentMenu .title h3").html("Kies een werelddeel");
}

//Toont de bollen met de mogelijke landen
ChooseKlimatogram.prototype.showLanden = function () {
    var self = this;
    //self.drawMap('Country', "", geefCorrecteOptions("countries", continentNaam));

    self.vulData('land', "", 1);
    self.vulOptions(self.continent.continentCode, 'countries');
    self.chart.draw(self.data, self.options);

    var content = $(".continentMenu .flex");
    content.html("");
    $.each(this.landen, function (index, item) {
        var div = $("<div/>");
        div.addClass("continentButton");
        var link = $("<a/>");
        link.attr("id", item.naam);
        link.append(item.naam);
        link.attr("style", "cursor: pointer");
        link.click(function () {
            self.land = item;
            self.getLocaties();
        });
        link.hover(function () {
            //Hover over een land, naam land zit in link.attr("id")
            self.vulData('land', item.naam, 1);
            self.chart.draw(self.data, self.options);
        }, function () {
            //Hover is gedaan
            self.vulData('land', "", 1);
            self.chart.draw(self.data, self.options);
        });
        div.append(link);
        content.append(div);
    });
    $(".continentMenu .title h3").html("Kies een land");
}

//Toont de bollen met mogelijke locaties
ChooseKlimatogram.prototype.showLocaties = function () {
    var self = this;

    self.vulData('stad', null, null);
    self.vulOptions(self.land.landCode, 'countries');
    self.chart.draw(self.data, self.options);

    var content = $(".continentMenu .flex");
    content.html("");
    $.each(this.locaties, function (index, item) {
        var div = $("<div/>");
        div.addClass("continentButton");
        var link = $("<a/>");
        link.attr("id", item.naam);
        link.append(item.naam);
        link.hover(function () {
            //Hover over een locatie, naam locatie zit in link.attr("id")
            self.vulData('stad', item.breedtegraad, item.lengtegraad);
            self.chart.draw(self.data, self.options);
        }, function () {
            //Hover is gedaan
            self.vulData('stad', null, null);
            self.chart.draw(self.data, self.options);
        });
        link.attr("style", "cursor: pointer");
        link.attr("href", 'SelecteerLocatie?continentNaam=' + self.continent.naam + '&landNaam=' + self.land.naam + '&locatieNaam=' + link.attr("id"));
        div.append(link);
        content.append(div);
    });
    $(".continentMenu .title h3").html("Kies een locatie");
}

/*
 *===================================================================
 *============ Transacties met controller ===========================
 *===================================================================
*/

//Haalt de werelddelen op
ChooseKlimatogram.prototype.getContinenten = function () {
    var self = this;
    $.getJSON("/Klimatogram/GetContinenten", function (data) {
        self.continenten = $.map(data, function (continent) {
            return new Continent(continent.Naam, continent.ContinentCode);
        });
        self.showContinenten();
    });
}

//Haalt de landen van het gekozen werelddeel op
ChooseKlimatogram.prototype.getLanden = function () {
    var self = this;
    $.getJSON("/Klimatogram/GetLanden", { continentNaam: self.continent.naam }, function (data) {
        self.landen = $.map(data, function (land) {
            return new Land(land.Naam, land.LandCode);
        });
        self.showLanden();
    });
}

//Haalt de locaties van het gekozen land op
ChooseKlimatogram.prototype.getLocaties = function () {
    var self = this;
    $.getJSON("/Klimatogram/GetLocaties", { continentNaam: self.continent.naam, landNaam: self.land.naam }, function (data) {
        self.locaties = $.map(data, function (locatie) {
            return new Locatie(locatie.Naam, locatie.Lengtegraad, locatie.Breedtegraad);
        });
        self.showLocaties();
    });
}

/*
 *===================================================================
 *============ Fuctie om de map te tekenen ===========================
 *===================================================================
*/

ChooseKlimatogram.prototype.vulData = function (plaats, data, data2) {
    switch (plaats.toLowerCase()) {
        case 'continent':
            this.data = google.visualization.arrayToDataTable([
                ['Region Code', 'Popularity'],
                [data, data2]]);
            break;
        case 'land':
            this.data = google.visualization.arrayToDataTable([
                ['Country', 'Popularity'],
                [data, data2]]);
            break;
        case 'stad':
            this.data = google.visualization.arrayToDataTable([
                ['Lat', 'Long'],
                [data, data2]]);
            break;
    }
}

ChooseKlimatogram.prototype.vulOptions = function (plaatsCode, verdeling) {
    this.options = {
        region: plaatsCode,
        resolution: verdeling,
        width: "100%",
        height: "100%",
        legend: 'none',
        enableRegionInteractivity: false
    };
}

/*
 *===================================================================
 *============ Document is geladen ===========================
 *===================================================================
*/
//View die alles verzorgt
var view = new ChooseKlimatogram();

$(document).ready(function () {
    google.setOnLoadCallback(view.getContinenten());
});





