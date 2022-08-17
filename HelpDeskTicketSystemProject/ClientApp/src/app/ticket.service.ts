import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  constructor(private http:HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  endpoint:string = "api/Ticket"

  showAllTickets():any{
    return this.http.get(this.baseUrl+this.endpoint+"/ShowAllTickets");
  }
}
