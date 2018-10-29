<h3>Api doc</h3>
<h3>Stores</h3>
Dokumentation för alla stores APIer. Svaren är i JSON format.
<h3>GET</h3>
<h4>Inventories API</h4><br>
https://devopstoresapp.herokuapp.com/api/inventories/stores

```
{
"storeId":3,
"prodId":1111,
"qty":2
},
```
/api/iventories/stores/1
```
{
(database id) : "id":4, 
"storeId":1,
"prodId":321,
"qty":22
}



<br><h4>Stores API</h4><br>
https://devopstoresapp.herokuapp.com/api/stores
<br>Default: Listar ut alla butikers information.


```
{
storeId":1,
"storeName":"Helsinki",
"address":"Mannerheimintie 8",
"zipCode":"00100",
"phoneNo":"+358123456"
},
```
