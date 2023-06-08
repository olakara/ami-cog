# Domain Model

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
  "id":"00000000-0000-0000-0000-000000000000",
  "name": "Sample Menu",
  "description": "A sample description on menu",
  "averageRating": 4.5,
  "sections": [
    {
      "id": "00000000-0000-0000-0000-000000000000",
      "name": "Fried Water",
      "description": "Deep fried water!",
      "price": 5.99
    }
  ],
  "createdDate": "2020-01-01T00:00:0000000Z",
  "updatedDate": "2020-01-01T00:00:0000000Z",
  "hostId": "00000000-0000-0000-0000-000000000000",
  "dinnerIds": [
    "00000000-0000-0000-0000-000000000000",    
  ],
  "menuReviewIds": [
    "00000000-0000-0000-0000-000000000000",
  ]
}
```