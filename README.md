# SimpleSeoMonitor
Simple SEO Monitor is a handy web app that helps you track how often and where your website shows up in search engine results for specific keywords, no need for manual searching! It’s built with C# and .NET Core on the back-end and Angular on the front-end.

# Technical Stack
- **Back-end:** C#, .NET 9, xUnit, Moq, FluentAssertions  
- **Front-end:** Angular 19, TypeScript  

# Search Engine Query Tips (Updated: 21/02/2025)
- **Bing:** `search?q=giá&first=1&count=10`  
  - `q`: Search query string  
  - `first`: Starting item index  
  - `count`: Number of items per page (Currently, the max is ~50, but it's not stable. A value of 10 is more reliable.)  

- **Google:** `search?q=giá&start=0&num=100`  
  - `q`: Search query string  
  - `start`: Starting item index  
  - `num`: Number of items per page (No known max limit; works reliably with `num=100`.)  

## 📮Contact
If you have any questions, feel free to reach out via email: *phattrandev@gmail.com* 📨
