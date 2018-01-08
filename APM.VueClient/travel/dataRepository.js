const SERVER_PATH = 'http://localhost:14340/api/';
const VEHICLE_SERVICE = SERVER_PATH + "vehicle";
const CURRENCY_SERVICE = SERVER_PATH + "currency";
const TOWN_SERVICE = SERVER_PATH + "town";

var travel=null;

var currecy_list = null;

var vehicles = [];

var countries = [{ "id": 1, "name": "Hrvatska", "day_amount": 140, "currency":"HRK" },
    { "id": 2, "name": "Austria", "day_amount": 70, "currency": "EUR" }];

var towns = [];

var company = {
    "name": 'INFORBIS', "address": 'Trnjanska cesta 11a',
    "town": { "id": 1, "name": "Zagreb", "country": { "id": 1, "name": "Hrvatska" } }
};

var cost_type_list = [
    { "id": 1, "name": 'Vinjeta Slovenija', "unit_price": 15, "currency": { "id": 'EUR', ex_rate: 7.54334 } },
    { "id": 2, "name": 'Vinjeta Austrija', "unit_price": 8, "currency": { "id": 'EUR', ex_rate: 7.54334 } },
    { "id": 3, "name": 'Cestarina', "unit_price": 48, "currency": { "id": 'HRK', ex_rate: 1 }  }
];

var unit_km_amount = 2.0;

moment.locale("hr"); 

var init_order = {
    "travel_date": getDate(),
    "town_to": 0,
    "vehicle":0,
    "travel_start": getDateTime(),
    "travel_finish": getDateTime(),
    "travel_duration": 0,
    "relations": [{"id":1,
            "town_from": { "id": 1, "name": "Zagreb", "country": { "id": 1, "name": "Hrvatska" },"citizens": 720000 },
            "town_to": { "id": 2, "name": "Deutschlandsberg", "country": { "id": 2, "name": "Austria" }, "citizens": 6500 },
            "km_at_start": 265000,
            "km_at_finish": null,
            "km": 233,
            "amount":0.0},
        {"id": 2,
            "town_from": { "id": 2, "name": "Deutschlandsberg", "country": { "id": 2, "name": "Austria" }, "citizens": 6500 },
            "town_to": { "id": 1, "name": "Zagreb", "country": { "id": 1, "name": "Hrvatska" }, "citizens": 720000 },
        "km_at_start": null,
        "km_at_finish": 265247,
        "km": 120,
        "amount": 0.0
        }],
    "costs": [{
        "id": 1, "cost_type": { "id": 1, "name": 'Vinjeta Slovenija', "unit_price": 15, "currency": { "id": 'EUR', ex_rate: 7.54334 } },
          "cost_description": "334343434", "cost_unit_price": 2.0, "cost_qty": 1.0, "cost_amount": 0.0
    }],
    "total_km":0,
    "total_km_amount": 0.0,
    "total_costs":0.0
}; 

