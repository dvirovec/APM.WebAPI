var currecy = [{ "id": 'EUR', ex_rate: 1 }, { "id": 'EUR', ex_rate: 7.54334 }];

var countries = [{ "id": 1, "name": "Hrvatska", "day_amount": 140, "currency":"HRK" },
    { "id": 2, "name": "Austria", "day_amount": 70, "currency": "EUR" }];

var towns = [{ "id": 1, "name": "Zagreb", "country": { "id": 1, "name": "Hrvatska" } },
{ "id": 2, "name": "Deutschlandsberg", "country": { "id": 2, "name": "Austria" } },
{ "id": 3, "name": "Đurđevac", "country": { "id": 1, "name": "Hrvatska" } }];

var company = {
    "name": 'INFORBIS', "address": 'Trnjanska cesta 11a',
    "town": { "id": 1, "name": "Zagreb", "country": { "id": 1, "name": "Hrvatska" } }
};

var init_order = {
    "town_from": 0,
    "town_to": 0,
    "relations": [{
        "town_from": { "id": 1, "name": "Zagreb", "country": { "id": 1, "name": "Hrvatska" } },
        "town_to": { "id": 2, "name": "Deutschlandsberg", "country": { "id": 2, "name": "Austria" } },
        "km": 233
    },
    {
        "town_from": { "id": 1, "name": "Zagreb", "country": { "id": 1, "name": "Hrvatska" } },
        "town_to": { "id": 3, "name": "Đurđevac", "country": { "id": 1, "name": "Hrvatska" } }, "km": 120
    }]
}; 

