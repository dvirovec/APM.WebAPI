var currecy_list = [{ "id": 'HRK', ex_rate: 1 }, { "id": 'EUR', ex_rate: 7.54334 }];

var vehicles = [{ 'id': 1, 'name': "Passat ZG-8184-DS", "private": true },
                { 'id': 2, 'name': "Audi ZG-2184-ED", "private": false }];


var countries = [{ "id": 1, "name": "Hrvatska", "day_amount": 140, "currency":"HRK" },
    { "id": 2, "name": "Austria", "day_amount": 70, "currency": "EUR" }];

var towns = [{ "id": 1, "name": "Zagreb", "country": { "id": 1, "name": "Hrvatska" } },
{ "id": 2, "name": "Deutschlandsberg", "country": { "id": 2, "name": "Austria" } },
{ "id": 3, "name": "Đurđevac", "country": { "id": 1, "name": "Hrvatska" } }];

var company = {
    "name": 'INFORBIS', "address": 'Trnjanska cesta 11a',
    "town": { "id": 1, "name": "Zagreb", "country": { "id": 1, "name": "Hrvatska" } }
};

var cost_type_list = [
    { "id": 1, "description": 'Vinjeta Slovenija', "unit_price": 15, "currency": { "id": 'EUR', ex_rate: 7.54334 } },
    { "id": 2, "description": 'Vinjeta Austrija', "unit_price": 8, "currency": { "id": 'EUR', ex_rate: 7.54334 } },
    { "id": 3, "description": 'Cestarina', "unit_price": 48, "currency": { "id": 'HRK', ex_rate: 1 }  }
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
            "town_from": { "id": 1, "name": "Zagreb", "country": { "id": 1, "name": "Hrvatska" } },
            "town_to": { "id": 2, "name": "Deutschlandsberg", "country": { "id": 2, "name": "Austria" } },
            "km_at_start": 0,
            "km_at_finish": 0,
            "km": 233,
            "amount":0.0
        },
        {
        "id": 2,
        "town_from": { "id": 2, "name": "Deutschlandsberg", "country": { "id": 2, "name": "Austria" } },
        "town_to": { "id": 1, "name": "Zagreb", "country": { "id": 1, "name": "Hrvatska" } },
        "km_at_start": 0,
        "km_at_finish": 0,
        "km": 120,
        "amount": 0.0
        }],
    "costs": [],
    "total_km":0,
    "total_km_amount": 0.0,
    "total_costs":0.0
}; 

