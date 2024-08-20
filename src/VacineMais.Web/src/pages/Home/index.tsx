export function Home() {
  return (
  

  <>
      <p>Página Home</p>

      <div class="off-screen-menu">
<ul>
<li><a href="/CarteiraVacinacao">Carteira Vacinação</a></li>
<li><a href="/NovoMembro">Novo Membro</a></li>
<li><a href="/NovoRegistro">Novo Registro</a></li>
</ul>
</div>

<nav>
<div class="ham-menu">
<span></span>
<span></span>
<span></span>
</div>
</nav>
  
    </>
  );
}

const hamMenu = document.querySelector(".ham-menu");

const offScreenMenu = document.querySelector(".off-screen-menu");

hamMenu.addEventListener("click", () => {
  hamMenu.classList.toggle("active");
  offScreenMenu.classList.toggle("active");
});