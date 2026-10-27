$contact = Get-Content 'contact.html' -Raw -Encoding UTF8
Write-Host "Contact title: " ([regex]::Match($contact, '<title>(.*?)</title>').Groups[1].Value)
Write-Host "Contact breadcrumb: " ([regex]::Match($contact, '<div class="breadcrumb__text">[\s\S]*?</div>').Value)
Write-Host "Contact widgets: "
[regex]::Matches($contact, '<div class="contact__widget">[\s\S]*?</div>') | ForEach-Object { Write-Host $_.Value.Trim() }
Write-Host "Map iframe: " ([regex]::Match($contact, '<div class="map">[\s\S]*?</div>').Value)
Write-Host "Form title: " ([regex]::Match($contact, '<div class="contact__form__title">[\s\S]*?</div>').Value)
