import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FavoriteService } from '../favorite.service';
import { TicketService } from '../ticket.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private favoriteService:FavoriteService, private router:Router) { }
addUserName(form:NgForm):void{
  FavoriteService.userName = form.form.value.userName;
  this.router.navigateByUrl('/tickets')
}

}
