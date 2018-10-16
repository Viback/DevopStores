GET api/stores
 [{
"storeId":1,
"storeName":"Helsinki",
"address":"Mannerheimintie 8",
"zipCode":"00100",
"phoneNo":"+358123456"
},
{
"storeId":2,
"storeName":"Turku",
"address":"Artturinkatu 37 B",
"zipCode":"20200",
"phoneNo":"+358654321"
},
{
"storeId":3,
"storeName":"Tampere",
"address":"H‰meenkatu 11 C",
"zipCode":"33200",
"phoneNo":"+3580000987"
},
{
"storeId":4,
"storeName":"Oulu",
"address":"Aittatori 5",
"zipCode":"90100",
"phoneNo":"+3580000456"
}]
 GET /api/stores/1
 {
"storeId":1,
"storeName":"Helsinki",
"address":"Mannerheimintie 8",
"zipCode":"00100",
"phoneNo":"+358123456"
}
 GET api/inventories
 [{
"id":1,
"storeId":3,
"prodId":1111,
"qty":2
},
{
"id":2,
"storeId":4,
"prodId":1111,
"qty":7
},
{
"id":4,
"storeId":3,
"prodId":123,
"qty":11
},
{
"id":6,
"storeId":1,
"prodId":321,
"qty":22
},
{
"id":7,
"storeId":2,
"prodId":321,
"qty":3
},
{
"id":8,
"storeId":4,
"prodId":222,
"qty":32
},
{
"id":9,
"storeId":3,
"prodId":222,
"qty":1
}]
 GET /api/inventories/3
 [{
"id":1,
"storeId":3,
"prodId":1111,
"qty":2
},
{
"id":4,
"storeId":3,
"prodId":123,
"qty":11
},
{
"id":9,
"storeId":3,
"prodId":222,
"qty":1
}]
 GET /api/inventories/3/123
 [{
"id":4,
"storeId":3,
"prodId":123,
"qty":11
}]
 GET api/stores_with_product/1111
 [3,4]
 Or
 {
"id":1,
"qty":2
},
{
"id":4,
"qty":7
}
