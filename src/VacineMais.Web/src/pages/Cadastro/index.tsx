import { FormEvent, useRef } from "react";
import { CadastroDTO } from "../../@types/CadastroDTO";
import Styles from "./cadastro.module.css";

export function Cadastro() {
  const cadastroFormRef = useRef<HTMLFormElement>(null);
  const emailRef = useRef<HTMLInputElement>(null);
  const usuarioRef = useRef<HTMLInputElement>(null);
  const senhaRef = useRef<HTMLInputElement>(null);
  const confirmarSenhaRef = useRef<HTMLInputElement>(null);

  async function handleFormSubmit(e: FormEvent) {
    e.preventDefault();

    const formData = new FormData(cadastroFormRef.current as HTMLFormElement);

    const dto: CadastroDTO = {
      username: formData.get("username") as string,
      email: formData.get("email") as string,
      password: formData.get("password") as string,
    };

    try {
      const response = await fetch(
        "https://localhost:7168/api/Auth/Cadastrar",
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(dto),
        }
      );

      if (!response.ok) {
        throw new Error("Erro ao enviar formulário");
      }

      const data = await response.json();
    } catch (error) {
      console.error(error);
    }
  }

  return (
    <>
      <h1>Faça o seu cadastro</h1>
      <form action="" onSubmit={handleFormSubmit} ref={cadastroFormRef}>
        <legend hidden={true}>Faça o seu cadastro!</legend>
        <label className={Styles.form__label} htmlFor="email">
          Email
        </label>
        <input type="text" id="email" name="email" ref={emailRef} required />
        <label className={Styles.form__label} htmlFor="username">
          Usuário
        </label>
        <input
          type="text"
          id="usuario"
          name="username"
          ref={usuarioRef}
          required
        />
        <label className={Styles.form__label} htmlFor="senha">
          Senha
        </label>
        <input
          type="password"
          id="senha"
          name="password"
          ref={senhaRef}
          required
        />
        <label className={Styles.form__label} htmlFor="confirmarSenha">
          Confirme sua senha
        </label>
        <input
          type="password"
          id="confirmarSenha"
          name="confirmarSenha"
          ref={confirmarSenhaRef}
        />
        <button className={Styles.form__button} type="submit">
          Cadastrar
        </button>
      </form>
    </>
  );
}
