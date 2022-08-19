import { Component } from '@angular/core';
import { FavoriteService } from '../favorite.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  logInName:string = FavoriteService.userName;
  constructor(private favoriteService:FavoriteService) { }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  getLogIn():any{
    return FavoriteService.userName;
  }
}
