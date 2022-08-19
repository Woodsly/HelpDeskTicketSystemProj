import { Component, OnInit } from '@angular/core';
import { FavoriteService } from '../favorite.service';
import { Ticket } from '../ticket';

@Component({
  selector: 'app-favorite',
  templateUrl: './favorite.component.html',
  styleUrls: ['./favorite.component.css']
})
export class FavoriteComponent implements OnInit {
  favoriteTickets:Ticket[] = [];
  constructor(private favoriteService:FavoriteService) { }

  ngOnInit(): void {
    this.favoriteService.ShowFavoriteTickets().subscribe((response:Ticket[]) => {
      this.favoriteTickets = response;
      console.log(response);
    });
  }

}
