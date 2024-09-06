import { useRef } from "react";
import { Button, Form } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

export function NovoMembro() {
  const navigate = useNavigate();

  const membroFormRef = useRef(null);
  const nomeRef = useRef(null);
  const dataNascimentoRef = useRef(null);

  async function handleFormSubmit(e) {
    e.preventDefault();

    const formData = new FormData(membroFormRef.current);

    const novoMembro = {
      nome: formData.get("nome"),
      dataNascimento: formData.get("dataNascimento"),
    };

    try {
      const response = await fetch("https://localhost:7168/api/Membro/Cadastrar", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(novoMembro),
      });

      if (!response.ok) {
        const data = await response.json();
        let msgErro = "";
        if (data.erro) {
          msgErro = data.erro;
        }
        throw new Error(`Não foi possível cadastrar o membro: ${msgErro}`);
      }

      alert("Membro cadastrado com sucesso!");
      resetForm();
      navigate("/home");
    } catch (error) {
      alert(error);
    }

    function resetForm() {
      formData.forEach((_, key) => {
        const input = membroFormRef.current?.elements.namedItem(key);
        if (input) {
          input.value = "";
        }
      });
    }
  }

  return (
    <div className="container">
      <h1>Cadastrar Novo Membro</h1>
      <Form action="" onSubmit={handleFormSubmit} ref={membroFormRef}>
        <legend hidden={true}>Novo Membro</legend>
        <Form.Group>
          <Form.Label htmlFor="nome">Nome</Form.Label>
          <Form.Control
            className="mb-3"
            type="text"
            id="nome"
            name="nome"
            placeholder="Digite o nome"
            ref={nomeRef}
            required
          />
        </Form.Group>
        <Form.Group>
          <Form.Label htmlFor="dataNascimento">Data de Nascimento</Form.Label>
          <Form.Control
            className="mb-3"
            type="date"
            id="dataNascimento"
            name="dataNascimento"
            ref={dataNascimentoRef}
            required
          />
        </Form.Group>
        <Button className="mx-auto d-block" variant="primary" type="submit">
         
        </Button>
      </Form>
    </div>
  );
}