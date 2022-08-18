import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Ticket } from '../ticket';
import { TicketService } from '../ticket.service';

@Component({
  selector: 'app-ticket-details',
  templateUrl: './ticket-details.component.html',
  styleUrls: ['./ticket-details.component.css']
})
export class TicketDetailsComponent implements OnInit {
  displayTicket:Ticket = {} as Ticket;
  constructor(private ticketService:TicketService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    let params = this.route.snapshot.paramMap;
    let id:number = Number(params.get("id"));
    this.ticketService.getTicketById(id).subscribe((response:Ticket) => {
      this.displayTicket = response;
      console.log(response);
    });
  }

  addResolution(form:NgForm):void{
    let params = this.route.snapshot.paramMap;
    let id:number = Number(params.get("id"));
    this.ticketService.resolveTicket(id, form).subscribe((response:Ticket) => {
      console.log(response);
    })
    
  }

  // addToFavorites():void{

  // }

}
