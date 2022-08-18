import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Ticket } from './ticket';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  constructor(private http:HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  endpoint:string = "api/Ticket"

  showAllTickets():any{
    return this.http.get(this.baseUrl+this.endpoint+"/ShowAllTickets");
  }

  getTicketById(id:number):any{
    return this.http.get(`${this.baseUrl}${this.endpoint}/GetTicketById/${id}`);
  }


  addTicket(newTicket:Ticket):any{
    return this.http.post(`${this.baseUrl}${this.endpoint}/AddAPost?UserName=${newTicket.userName}&SubjectLine=${newTicket.subjectLine}&QuestionDetails=${newTicket.questionDetails}&Status=${newTicket.status}`,{});
  }

  resolveTicket(theTicketId:number, form:NgForm):any{
    return this.http.patch(`${this.baseUrl}${this.endpoint}/ResolveTicket?id=${theTicketId}&ResolvedBy=${form.form.value.resolvedBy}&Resolution=${form.form.value.resolution}`,{});
  }


  
}
