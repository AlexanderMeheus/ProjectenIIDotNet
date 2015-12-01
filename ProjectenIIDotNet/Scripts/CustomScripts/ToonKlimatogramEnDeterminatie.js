/*
========================================================================================
======================================= Determinatie ===================================
========================================================================================
*/

//Constructor van DeterminatieVraag die de gegevens juist zet
//adhv determinatieVraagViewModel
function DeterminatieVraag(determinatieVraag) {
    this.KorteVraag = determinatieVraag.GeefVerkorteVraag;
    this.LangeVraag = determinatieVraag.GeefVolledigeVraag;
}

//Constructor van Kenmerk die de gegevens juist zet
//adhv kenmerkViewModel
function Kenmerk(kenmerk) {
    this.Klimaat = kenmerk.KlimaatKenmerk;
    this.Vegetatie = kenmerk.VegetatieKenmerk;
}

//Constructor van node die alle gegevens juist zet
//adhv nodeViewModel
function Node(node) {
    viewDeterminatie.setKey(this);
    this.IsVraag = node.IsVraag;
    this.IsHuidige = node.IsHuidige;
    if (this.IsHuidige) viewDeterminatie.Huidige = this;
    if (this.IsVraag) {
        this.DeterminatieVraag = new DeterminatieVraag(node.Vraag);
        this.JaKind = new Node(node.JaKind);
        this.JaKind.Ouder = this;
        this.NeeKind = new Node(node.NeeKind);
        this.NeeKind.Ouder = this;
        if (this.DeterminatieVraag.KorteVraag.length > viewDeterminatie.MaxVraagBreedte) viewDeterminatie.MaxVraagBreedte = this.DeterminatieVraag.KorteVraag.length;
    } else {
        this.Kenmerk = new Kenmerk(node.Kenmerk);
        if (this.Kenmerk.Klimaat.length > viewDeterminatie.MaxKenmerkBreedte) viewDeterminatie.MaxKenmerkBreedte = this.Kenmerk.Klimaat.length;
    }
}

//Iedere node zorgt dat hij zichzelf kan tekenen.
Node.prototype.draw = function (builder, data, links, posX) {
    var self = this;
    var kleur = "lightblue";
    var tekst = "";
    var breedte = viewDeterminatie.VraagBreedte;
    var hoogte = viewDeterminatie.MaxNodeHoogte;
    var position = "" + (posX * (breedte + viewDeterminatie.marginHorizontaal)) + " " + (viewDeterminatie.posY * (viewDeterminatie.MaxNodeHoogte + viewDeterminatie.marginVerticaal));
    if (self.IsHuidige) kleur = "lightgreen";
    if (self.IsVraag) tekst = self.DeterminatieVraag.KorteVraag;
    else {
        tekst = self.Kenmerk.Klimaat;
        position = "" + (viewDeterminatie.Breedte * (viewDeterminatie.VraagBreedte + viewDeterminatie.marginHorizontaal)) + " " + (viewDeterminatie.posY * (viewDeterminatie.MaxNodeHoogte + viewDeterminatie.marginVerticaal));
        breedte = viewDeterminatie.KenmerkBreedte;
    }
    
    data.push({ key: self.Key, kleur: kleur, tekst: tekst, loc: position, breedte: breedte, hoogte: hoogte });

    if (self.IsVraag) {
        self.JaKind.draw(builder, data, links, posX + 1);
        self.NeeKind.draw(builder, data, links, posX);
        links.push({ from: self.Key, to: self.JaKind.Key, fromSpot: "Right", toSpot: "Left", label: "Ja" });


        if (self.NeeKind.IsVraag) links.push({ from: self.Key, to: self.NeeKind.Key, fromSpot: "Bottom", toSpot: "Top", label: "Nee" });
        else links.push({ from: self.Key, to: self.NeeKind.Key, fromSpot: "Bottom", toSpot: "Left", label: "Nee" });
    } else {
        ++viewDeterminatie.posY;
    }
}

//Constructor van determinatietree. Deze zet alle waarden initieel.
//Voor het tekenen wordt eerst gekeken of er een div met id DeterminatieTree bestaat.
function DeterminatieTree() {
    this.Graad = null;
    this.Root = null;
    this.Huidige = null;
    this.Breedte = 0;
    this.Hoogte = 0;
    this.MaxVraagBreedte = 0;
    this.MaxKenmerkBreedte = 0;
    this.VraagBreedte = 0;
    this.KenmerkBreedte = 0;
    this.marginHorizontaal = 75;
    this.marginVerticaal = 30;
    this.MaxNodeHoogte = 30;
    this.posY = 0;
    this.currentKey = 0;
    this.Oplossing = null;
    this.Image = null;
    this.Content = $("#DeterminatieTree");
    this.Draw = (this.Content.length > 0);
    if (this.Draw) {
        this.Content.html("");
        this.Content.addClass("determineerTabel");

        var tmp = $("<div/>");
        tmp.attr("id", "TabelContent");
        this.Content.append(tmp);
        this.TabelContent = $("#TabelContent");
        this.TabelContent.attr("style", "width: 0px; height: 0px;");

        tmp = $("<div/>");
        tmp.attr("id", "VraagContent");
        this.Content.append(tmp);
        this.VraagContent = $("#VraagContent");

        this.Diagram = new go.Diagram("TabelContent");
    }
}

//Iedere node heeft een unieke key nodig om in GoJS
//een lijn te kunnen trekken. Deze functie voorziet incrementeel
//een key in de vorm van "Kx" met x een cijfer die blijft optellen.
DeterminatieTree.prototype.setKey = function (node) {
    node.Key = "K" + this.currentKey;
    ++this.currentKey;
}

//Functie die met behulp van een determinatieTreeViewModel een volledige
//boom kan tekenen, mbv GoJS, hier worden alle objecten aangemaakt en ingesteld.
DeterminatieTree.prototype.buildTree = function (determinatieTreeViewModel) {
    var self = this;
    self.Graad = determinatieTreeViewModel.Graad;
    self.Root = new Node(determinatieTreeViewModel.Root);
    self.Breedte = determinatieTreeViewModel.Breedte;
    self.Hoogte = determinatieTreeViewModel.Hoogte;

    self.VraagBreedte = 7 * self.MaxVraagBreedte;
    self.KenmerkBreedte = 7 * self.MaxKenmerkBreedte;

    self.TabelContent.attr("style", "width: " + (((self.Breedte) * (self.VraagBreedte + self.marginHorizontaal)) + (2 * (self.KenmerkBreedte + self.marginHorizontaal))) + "px; height: " + (self.Hoogte * (self.MaxNodeHoogte + self.marginVerticaal)) + "px;");
    self.show();
}

//Zet alles correct om via GoJS een boom te tekenen en dit op het scherm te plaatsen.
DeterminatieTree.prototype.show = function () {
    var self = this;
    var builder = go.GraphObject.make;

    self.Diagram.nodeTemplate = builder(go.Node, "Auto",
                new go.Binding("location", "loc", go.Point.parse),
                { movable: false, selectable: false },
                builder(go.Shape, "RoundedRectangle", { fill: "lightblue" }, new go.Binding("fill", "kleur"), new go.Binding("width", "breedte"), new go.Binding("height", "hoogte")),
                builder(go.TextBlock, new go.Binding("text", "tekst"), { alignment: go.Spot.Center  })
         );

    self.Diagram.linkTemplate = builder(go.Link,
                { routing: go.Link.Orthogonal, movable: false, selectable: false },
                new go.Binding("fromSpot", "fromSpot", go.Spot.parse),
                new go.Binding("toSpot", "toSpot", go.Spot.parse),
                builder(go.Shape),
                builder(go.Shape, { toArrow: "Standard" }),
                builder(go.TextBlock,
                    { segmentIndex: 0, segmentOffset: new go.Point(NaN, NaN) },
                    new go.Binding("text", "label"))
                );
    var data = [];
    var links = [];
    self.posY = 0;
    self.Root.draw(builder, data, links, 0);
    self.Diagram.model = new go.GraphLinksModel(data, links);
    var img = self.Diagram.makeImage();
    self.TabelContent.attr("style", "");
    self.TabelContent.html("");

    self.Content.addClass("hidden");
    self.Content.addClass("visuallyhidden");
    self.TabelContent.append(img);
    $("#TabelContent img").addClass("img-responsive");

    self.showVraag();
}

//Toont bij iedere node de volledige vraag die daarbij hoort.
//Indien er een leaf bereikt is wordt het Klimaat kenmerk getoond.
DeterminatieTree.prototype.showVraag = function () {
    var self = this;
    var vraag = this.VraagContent;
    vraag.html("");

    var para = $('<p>');
    var node = self.Huidige;

    if (node.IsVraag) {
        var v = node.DeterminatieVraag.LangeVraag;
        v = v[0].toUpperCase() + v.slice(1) + "?";
        para.append(v);
        var linkJa = $("<a/>");
        linkJa.append("Ja");
        linkJa.click(function () {
            self.StapVerder(true);
        });
        var linkNee = $("<a/>");
        linkNee.append("Nee");
        linkNee.click(function () {
            self.StapVerder(false);
        });
        vraag.append(para);

        linkJa.attr("style", "cursor: pointer");
        linkNee.attr("style", "cursor: pointer");
        vraag.append(linkJa).append(linkNee);

        if (node.Ouder != null) {
            var linkTerug = $("<a/>");
            linkTerug.append("Stap terug");
            linkTerug.click(function() {
                self.StapTerug();
            });
            linkTerug.attr("style", "cursor: pointer");
            vraag.append(linkTerug);
        }
    } else {
        para.append(node.Kenmerk.Klimaat);
        vraag.append(para);
        var linkControle = $("<a/>");
        linkControle.attr("id", node.Kenmerk.Klimaat);
        linkControle.append("Controlleer");
        linkControle.click(function() {
            self.ControlleerDeterminatie(linkControle.attr("id"));
        });
        linkControle.attr("style", "cursor: pointer");
        vraag.append(linkControle);
        if (node.Ouder != null) {
            var linkTerug = $("<a/>");
            linkTerug.append("Stap terug");
            linkTerug.click(function() {
                self.StapTerug();
            });
            linkTerug.attr("style", "cursor: pointer");
            vraag.append(linkTerug);
        }
    }

    self.Content.removeClass("hidden");
    self.Content.removeClass('visuallyhidden');
}

//Alle aanvragen naar de server hieronder

//Initieel de boom opvragen
DeterminatieTree.prototype.getTree = function () {
    var self = this;
    $.getJSON("/Determinatie/GetDeterminatieTree", function (determinatieTreeViewModel) {
        self.buildTree(determinatieTreeViewModel);
    });
}

//Wanneer een leaf is bereikt controlleren of de leerling correct is.
//Als het niet juist is wordt auto naar laatste juiste node gegaan.
DeterminatieTree.prototype.ControlleerDeterminatie = function(klimaat) {
    var self = this;
    $.getJSON("/Determinatie/IsDeterminatieCorrect?klimaat=" + klimaat, function (correct) {
        if (correct) {
            self.VraagContent.html("");
            self.toonFotoVegetatie();
        } else {
            self.getTree();
        }
    });
}

//Een stap verder zetten in de determinatie
DeterminatieTree.prototype.StapVerder = function(keuze) {
    var self = this;
    $.getJSON("/Determinatie/StapVerder?antwoord=" + keuze, function (determinatieTreeViewModel) {
        self.buildTree(determinatieTreeViewModel);
    });
}

//Een stap terug keren in de determinatie
DeterminatieTree.prototype.StapTerug = function () {
    var self = this;
    $.getJSON("/Determinatie/StapTerug", function (determinatieTreeViewModel) {
        self.buildTree(determinatieTreeViewModel);
    });
}


//Nadat de determinatie compleet is zorgen voor de juiste verwerking
//per graad en jaar

//Div met foto van vegetatietype en benaming van klimaat- en vegetatietype tonen
DeterminatieTree.prototype.toonFotoVegetatie = function() {
    var self = this;
    $.getJSON("/Determinatie/GetKenmerk", function (KenmerkViewModel) {
        var werkDiv = $("#werkgebied");
        var proficiat = $("<h2/>");
        proficiat.attr("id", "proficiat");
        proficiat.append("Gefeliciteerd, je hebt correct gedetermineerd.");

        var fotoDiv = $("<div/>");
        fotoDiv.attr("id", "fotoVegetatie");

        var img = $("<img/>");
        img.addClass("img-responsive");
        img.attr("src", "images/vegetaties/" + KenmerkViewModel.VegetatieKenmerk.replace(" ", "_") + ".png");
        fotoDiv.append(img);

        var tekstDiv = $("<div/>");
        tekstDiv.attr("id", "kenmerk");

        var dlKenmerk = $("<dl/>");
        dlKenmerk.addClass("dl-horizontal");

        var dt = $("<dt/>");
        var dd = $("<dd/>");
        dt.append("Klimaat");
        dd.append(KenmerkViewModel.KlimaatKenmerk);
        dlKenmerk.append(dt).append(dd);
        dt = $("<dt/>");
        dd = $("<dd/>");
        dt.append("Vegetatie");
        dd.append(KenmerkViewModel.VegetatieKenmerk);
        dlKenmerk.append(dt).append(dd);
        tekstDiv.append(dlKenmerk);

        werkDiv.append(proficiat).append(fotoDiv).append(tekstDiv);
    });
}

/*
========================================================================================
======================================= Klimatogram ====================================
========================================================================================
*/

function MaandGegeven(temperatuur, neerslag, maand, maandNummer) {
    this.temperatuur = temperatuur;
    this.neerslag = neerslag;
    this.maand = maand;
    this.maandNummer = maandNummer;
}

function Klimatogram(maandGegevens, continentNaam, landNaam, locatieNaam, totaalNeerslag, gemiddeldeJaarTemperatuur, startWaarnemingen, eindeWaarnemingen, coordinaten) {
    this.maandGegevens = maandGegevens;
    this.continentNaam = continentNaam;
    this.landNaam = landNaam;
    this.locatieNaam = locatieNaam;
    this.totaalNeerslag = totaalNeerslag;
    this.gemiddeldeJaarTemperatuur = gemiddeldeJaarTemperatuur;
    this.startWaarnemingen = startWaarnemingen;
    this.eindeWaarnemingen = eindeWaarnemingen;
    this.coordinaten = coordinaten;

}

function ShowKlimatogram() {
    this.ChartContent = null;
    this.TableContent = null;
    this.Content = $('#Klimatogram');
    this.Draw = ($('#Klimatogram').length > 0);
    if (this.Draw) {
        this.Content.html("");
        this.ChartContent = $('<div>');
        this.ChartContent.attr("id", "KlimatogramChartContent");
        this.TableContent = $('<div>');
        this.TableContent.attr("id", "KlimatogramTableContent");
    }
    this.klimatogram = null;
}

ShowKlimatogram.prototype.getKlimatogram = function () {
    var self = this;
    $.getJSON("../Klimatogram/GetKlimatogram", function (data) {
        self.klimatogram = new Klimatogram(
            $.map(data.MaandGegevens, function (maandGegeven) {
                return new MaandGegeven(maandGegeven.Temperatuur, maandGegeven.Neerslag, maandGegeven.Maand, maandGegeven.MaandNummer);
            }),
            data.ContinentNaam, data.LandNaam,
            data.LocatieNaam, data.TotaalNeerslag, data.GemiddeldeJaarTemperatuur, data.StartWaarnemingen, data.EindeWaarnemingen, data.Coordinaten);
        self.show();
    });
}

ShowKlimatogram.prototype.tekenChart = function () {
    var self = this;
    var neerslagen = [];
    var temperaturen = [];
    for (i = 0; i < self.klimatogram.maandGegevens.length; i++) {
        neerslagen[i] = self.klimatogram.maandGegevens[i].neerslag;
        temperaturen[i] = self.klimatogram.maandGegevens[i].temperatuur;
    }

    var max = 0;
    if (Math.max.apply(Math, neerslagen) > Math.max.apply(Math, temperaturen) * 2) {
        max = Math.max.apply(Math, neerslagen);
    } else {
        max = Math.max.apply(Math, temperaturen) * 2;
    }

    var min = 0;
    if (Math.min.apply(Math, temperaturen) < 0) {
        min = Math.min.apply(Math, temperaturen) * 2;
    } else {
        min = 0;
    }
    self.ChartContent.html("");
    self.ChartContent.highcharts({
        chart: {
            zoomType: 'xy',
            events: {
                load: Highcharts.drawTable
            }
        },
        title: {
            text: self.klimatogram.locatieNaam + " (" + self.klimatogram.landNaam + ") - " + self.klimatogram.coordinaten
        },
        subtitle: {
            text: 'Klimatologische gemiddelden' + self.klimatogram.startWaarnemingen + " - " + self.klimatogram.eindeWaarnemingen
        },
        xAxis: [
            {
                categories: [
                    'Jan', 'Feb', 'Mar', 'Apr', 'Mei', 'Jun',
                    'Jul', 'Aug', 'Sep', 'Okt', 'Nov', 'Dec'
                ],
                crosshair: true
            }
        ],
        yAxis: [
        {
            // Primary yAxis
            title: {
                text: 'Neerslag in mm',
                style: {
                    color: Highcharts.getOptions().colors[0]
                }
            },
            labels: {
                format: '{value}',
                style: {
                    color: Highcharts.getOptions().colors[0]
                }
            },
            max: max,
            min: min,
            tickInterval: 10
        }, {
            // Secondary yAxis
            title: {
                text: 'Temperatuur in °C',
                style: {
                    color: Highcharts.getOptions().colors[1]
                }
            },
            labels: {
                format: '{value}',
                style: {
                    color: Highcharts.getOptions().colors[1]
                }
            },
            opposite: true,
            max: (max / 2),
            min: (min / 2),
            tickInterval: 5
        }],
        tooltip: {
            shared: true
        },
        series: [{
            name: 'Neerslag in mm',
            type: 'column',
            data: neerslagen,
            tooltip: {
                valueSuffix: ' mm'
            }

        }, {
            name: 'Temperatuur in °C',
            type: 'spline',
            yAxis: 1,
            data: temperaturen,
            color: '#FF0000',
            tooltip: {
                valueSuffix: '°C'
            }
        }]
    });
}

//Teken de table met waarden uit de chart
ShowKlimatogram.prototype.tekenTabel = function () {
    var self = this;
    self.TableContent.html("");
    var tabel = "<table width=\"100%\" class=\"table-responsive\" border=\"1\"><tr><th/>";
    for (i = 0; i < self.klimatogram.maandGegevens.length; i++) {
        tabel += "<th>" + self.klimatogram.maandGegevens[i].maand.substring(0,3) + "</th>";
    }
    tabel += "</tr><tr><td>Neerslag (mm)</td>";
    for (i = 0; i < self.klimatogram.maandGegevens.length; i++) {
        tabel += "<td>" + self.klimatogram.maandGegevens[i].neerslag + "</td>";
    }
    tabel += "</tr><tr><td>Temperatuur (°C)</td>";
    for (i = 0; i < self.klimatogram.maandGegevens.length; i++) {
        tabel += "<td>" + self.klimatogram.maandGegevens[i].temperatuur + "</td>";
    }
    tabel += "</tr></table></br>";
    tabel += "<p>Totale jaar neerslag: " + self.klimatogram.totaalNeerslag + "mm</p>";
    tabel += "<p>Gemiddelde jaar temperatuur: " + self.klimatogram.gemiddeldeJaarTemperatuur + "°C</p>";
    self.TableContent.append(tabel);
}

//Chart en tabel op scherm plaatsen
ShowKlimatogram.prototype.show = function () {
    var self = this;
    if (self.Draw) {
        self.tekenChart();
        self.tekenTabel();
        self.Content.html("");
        self.Content.append(self.ChartContent);
        self.Content.append(self.TableContent);
    }
}

var viewKlimatogram = new ShowKlimatogram();
var viewDeterminatie = new DeterminatieTree();

$(document).ready(function () {
    if (viewKlimatogram.Draw) viewKlimatogram.getKlimatogram();
    if (viewDeterminatie.Draw) viewDeterminatie.getTree();
});