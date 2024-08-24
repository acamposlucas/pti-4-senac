import { useEffect, useRef, useState } from "react";
import { CarteiraVacinacao, Imunizacao } from "../../@types/CarteiraVacinacao";
import {
  Button,
  Card,
  CardBody,
  CardFooter,
  Form,
  Modal,
} from "react-bootstrap";
import { Imunobiologico } from "../../@types/Imunobiologico";
import { Dose } from "../../@types/Dose";

export function CarteiraVacinacaoPage() {
  const [carteiraVacinacao, setCarteiraVacinacao] =
    useState<CarteiraVacinacao>();

  const [atualizarCarteira, setAtualizarCarteira] = useState<boolean>(false);
  // const { user } = useContext(UserContext);

  useEffect(() => {
    setAtualizarCarteira(false);
    buscaCarteiraVacinacao();
  }, [atualizarCarteira]);

  async function buscaCarteiraVacinacao() {
    try {
      const response = await fetch(
        "https://localhost:7168/api/CarteiraVacinacao/1",
        {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
          },
        }
      );

      if (!response.ok) {
        throw new Error("Não foi possível abrir os dados desse membro");
      }

      const data: CarteiraVacinacao = await response.json();
      setCarteiraVacinacao(data);
    } catch (error) {
      alert(error);
    }
  }

  function handleAtualizarCarteira() {
    setAtualizarCarteira(true);
  }

  return (
    <div className="container">
      <h1>Carteira de vacinação</h1>
      <div className="d-flex flex-column">
        <strong>{carteiraVacinacao?.nome}</strong>
        <span>{carteiraVacinacao?.idade}</span>
      </div>
      <div className="d-flex flex-column gap-2">
        {carteiraVacinacao?.imunizacoes.map((i) => (
          <ImunizacaoCard
            imunizacao={i}
            handleAtualizarCarteira={handleAtualizarCarteira}
            key={i.id}
          />
        ))}
      </div>
    </div>
  );
}

function ImunizacaoCard({
  imunizacao,
  handleAtualizarCarteira,
}: {
  imunizacao: Imunizacao;
  handleAtualizarCarteira: () => void;
}) {
  const [showModalEditar, setShowModalEditar] = useState(false);
  const [showModalExcluir, setShowModalExcluir] = useState(false);
  const [imunobiologicos, setImunobiologicos] = useState<Imunobiologico[]>([]);
  const [doses, setDoses] = useState<Dose[]>([]);

  const atualizarImunizacaoFormRef = useRef<HTMLFormElement>(null);
  const vacinaRef = useRef<HTMLSelectElement>(null);
  const doseRef = useRef<HTMLSelectElement>(null);
  const proximaDoseRef = useRef<HTMLInputElement>(null);

  const handleCloseModalEditar = () => setShowModalEditar(false);
  const handleShowModalEditar = () => setShowModalEditar(true);

  const handleCloseModalExcluir = () => setShowModalExcluir(false);
  const handleShowModalExcluir = () => setShowModalExcluir(true);

  async function editarImunizacao() {
    const formData = new FormData(
      atualizarImunizacaoFormRef.current as HTMLFormElement
    );

    const proximaDoseEm =
      (formData.get("proximaDoseEm") as string) != ""
        ? (formData.get("proximaDoseEm") as string)
        : null;

    const dto = {
      id: imunizacao.id,
      membroId: imunizacao.membroId,
      imunobiologicoId: parseInt(
        formData.get("imunobiologico") as string
      ) as number,
      doseId: parseInt(formData.get("dose") as string) as number,
      proximaDoseEm,
    };
    try {
      const response = await fetch("https://localhost:7168/api/Imunizacao", {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(dto),
      });

      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(
          `Request failed: ${response.status} ${response.statusText} - ${errorText}`
        );
      }
      handleAtualizarCarteira();
      handleCloseModalEditar();
    } catch (error: any) {
      console.error("Falha na chamada à API:", error);
      alert("Falha ao atualizar imunização: " + error.message);
    }
  }

  async function configurarControlesModal() {
    await buscaImunobiologicos();
    await buscaDoses();
  }

  async function buscaImunobiologicos() {
    try {
      const response = await fetch(
        "https://localhost:7168/api/Imunobiologico",
        {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
          },
        }
      );

      if (!response.ok) {
        throw new Error("Não foi possível abrir os dados desse membro");
      }

      const data: Imunobiologico[] = await response.json();
      setImunobiologicos(data);
    } catch (error) {
      alert(error);
    }
  }

  async function buscaDoses() {
    try {
      const response = await fetch("https://localhost:7168/api/Dose", {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
        },
      });

      if (!response.ok) {
        throw new Error("Não foi possível abrir os dados desse membro");
      }

      const data: Dose[] = await response.json();
      setDoses(data);
    } catch (error) {
      alert(error);
    }
  }

  async function handleConfirmarExcluirVacina() {
    try {
      const response = await fetch(
        `https://localhost:7168/api/Imunizacao/${imunizacao.id}`,
        {
          method: "DELETE",
          headers: {
            "Content-Type": "application/json",
          },
        }
      );

      if (!response.ok) {
        throw new Error("Não foi possível deletar a vacina");
      }

      handleCloseModalExcluir();
      handleAtualizarCarteira();
    } catch (error) {
      alert(error);
    }
  }

  useEffect(() => {
    configurarControlesModal();
  }, [showModalEditar]);

  return (
    <>
      <Card key={imunizacao.id}>
        <CardBody>
          <strong>{imunizacao.descricaoImunobiologico}</strong>
          <p>{imunizacao.descricaoDose}</p>
          {imunizacao.proximaDoseEm ? <p>{imunizacao.proximaDoseEm}</p> : null}
        </CardBody>
        <CardFooter className="d-flex gap-2">
          <Button variant="secondary" onClick={handleShowModalEditar}>
            Editar
          </Button>
          <Button variant="danger" onClick={handleShowModalExcluir}>
            Excluir
          </Button>
        </CardFooter>
      </Card>
      <Modal show={showModalEditar} onHide={handleCloseModalEditar}>
        <Modal.Header closeButton>
          <Modal.Title>Editar vacina</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form ref={atualizarImunizacaoFormRef}>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
              <Form.Label id="imunobiologico">Vacina</Form.Label>
              {imunobiologicos.length > 0 ? (
                <Form.Select
                  id="imunobiologico"
                  name="imunobiologico"
                  ref={vacinaRef}
                >
                  {imunobiologicos.map((i) => (
                    <option key={i.id} value={i.id}>
                      {i.descricao}
                    </option>
                  ))}
                </Form.Select>
              ) : (
                <p>Carregando</p>
              )}
            </Form.Group>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
              <Form.Label id="dose">Dose</Form.Label>
              {doses.length > 0 ? (
                <Form.Select id="dose" name="dose" ref={doseRef}>
                  {doses.map((i) => (
                    <option key={i.id} value={i.id}>
                      {i.descricao}
                    </option>
                  ))}
                </Form.Select>
              ) : (
                <p>Carregando</p>
              )}
            </Form.Group>
            <Form.Group>
              <Form.Label htmlFor="proximaDoseEm">Próxima dose em:</Form.Label>
              <input
                ref={proximaDoseRef}
                className="ms-3"
                type="date"
                name="proximaDoseEm"
                id="proximaDoseEm"
              />
            </Form.Group>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleCloseModalEditar}>
            Close
          </Button>
          <Button variant="primary" onClick={editarImunizacao}>
            Atualizar
          </Button>
        </Modal.Footer>
      </Modal>
      <Modal show={showModalExcluir} onHide={handleCloseModalExcluir}>
        <Modal.Header closeButton>
          <Modal.Title>Excluir vacina</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <p>
            Confirma a exclusão do imunobiológico{" "}
            <strong>{imunizacao.descricaoImunobiologico}</strong>?
          </p>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleCloseModalExcluir}>
            Close
          </Button>
          <Button variant="danger" onClick={handleConfirmarExcluirVacina}>
            Excluir
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}
