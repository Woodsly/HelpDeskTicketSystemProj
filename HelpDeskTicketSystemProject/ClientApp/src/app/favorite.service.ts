import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FavoriteService {
  endPoint:string = "api/Favorite"
  public static userName:string;
  constructor(private http:HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  
  AddFavorite(id:number):any{
    return this.http.post(`${this.baseUrl}${this.endPoint}/AddFavorite?id=${id}&name=${FavoriteService.userName}`, {});
   };


  ShowFavoriteTickets():any{
    return this.http.get(`${this.baseUrl}${this.endPoint}/ShowFavoriteTickets?userName=${FavoriteService.userName}`);
  };

}
