import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FavoriteService } from '../favorite.service';
import { Ticket } from '../ticket';
import { TicketService } from '../ticket.service';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {
  name:string = FavoriteService.userName;
  tickets:Ticket[] = [];
  displayForm:boolean = false;
  constructor(private TicketService:TicketService) { }

  ngOnInit(): void {
    this.TicketService.showAllTickets().subscribe((response:Ticket[]) => {
      this.tickets = response;
      this.tickets.sort((a,b) => (a.dateOpened < b.dateOpened) ? 1 : ((b.dateOpened < a.dateOpened) ? -1 : 0));
      console.log(this.tickets);
      console.log(response);
    });
  }

  addTicket(form:NgForm):void{
    let newTicket:Ticket = {
      userName: form.form.value.userName,
      subjectLine: form.form.value.subjectLine,
      questionDetails: form.form.value.questionDetails,
      status: "Open",
      dateOpened: new Date(),
      favorited: false,
      id: 0,
      resolvedBy: "",
      dateClosed: new Date(),
      resolution: ""
    };
    this.TicketService.addTicket(newTicket).subscribe((response:Ticket) => {
      console.log(response);
      this.tickets.push(response);
      this.tickets = this.SortTickets();
    })
    this.toggleForm();
  }

  toggleForm():void{
    this.displayForm = !this.displayForm;
  }

  SortTickets():Ticket[]{
    return this.tickets.sort((a,b) => (a.dateOpened < b.dateOpened) ? 1 : ((b.dateOpened < a.dateOpened) ? -1 : 0));
  }
}
