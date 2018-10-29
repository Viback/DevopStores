<h3>Api doc</h3>
<h3>Stores</h3>
Dokumentation för alla stores APIer. Svaren är i JSON format.
<h3>GET</h3>
<h4>Inventories API</h4><br>

/api/inventories/stores
visar produkterna och databaserna som finns i databasen

```
{
"storeId":3,
"prodId":1111,
"qty":2
},
```
/api/iventories/stores/1 
visar vad som finns i butik(1:an)
<br>om det inte finns butiken man fösöker slippa till får man 404
```
{
(database id)"id":4, 
"storeId":1,
"prodId":321,
"qty":22
}
```

<br><h4>Stores API</h4><br>
https://devopstoresapp.herokuapp.com/api/stores
<br>Default: Listar ut alla butikers information.
<br>om butik id:n inte finns kommer de 404


```
{
storeId":1,
"storeName":"Helsinki",
"address":"Mannerheimintie 8",
"zipCode":"00100",
"phoneNo":"+358123456"
},
```

![error](https://user-images.githubusercontent.com/43543460/47654471-8ef69400-db93-11e8-88b2-ed8e25ccd06f.PNG)

