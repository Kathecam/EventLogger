import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-header',
  standalone: true,
  template: `
    <div class="flex justify-center p-20">
      <h1 class="text-3xl font-bold underline">
        Aplicación Event Logger
      </h1>
    </div>
  `,
  styleUrl: './header.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HeaderComponent { }
