import React, { Component } from "react";
import { withRouter } from "react-router-dom";

import CssBaseline from "@material-ui/core/CssBaseline";
import Grid from "@material-ui/core/Grid";
import Container from "@material-ui/core/Container";
import Typography from "@material-ui/core/Typography";
import FormControl from "@material-ui/core/FormControl";
import InputLabel from '@material-ui/core/InputLabel';
import Input from '@material-ui/core/Input';

import api from "../services/api";

class SignIn extends Component {
  constructor() {
    super();
    this.state = {
      nif: "",
      senha: "",
      error: ""
    };
  }

  efetuarLogin = async event => {
    event.preventDefault();

    const { nif, senha } = this.state;

    await api
      .post("/login", { nif, senha })
      .then(response => {
        if (response.status === 200) {
          console.log(response.data.token);
          localStorage.setItem("@sas-token", response.data.token);
          this.props.history.push("/home");
        } else {
          this.setState({ error: "Verifique suas credenciais." });
        }
      })
      .catch(erro => {
        this.setState({ error: "Usuário ou senha inválidos" });
      });
  };

  render() {
    return (
      <React.Fragment>
        <CssBaseline />
        <Container maxWidth="sm">
          <Typography component="div" style={{ height: "100vh" }}>
            <Grid
              container
              spacing={0}
              direction="row"
              alignItems="center"
              justify="center"
              style={{ minHeight: "100vh" }}
            >
              <FormControl>
                <InputLabel htmlFor="my-input">Email address</InputLabel>
                <Input id="my-input" aria-describedby="my-helper-text" />
              </FormControl>
              {/* <form onSubmit={this.efetuarLogin}>
                {this.state.error && <p>{this.state.error}</p>}
                <input
                  type="nif"
                  placeholder="NIF"
                  onChange={e => this.setState({ nif: e.target.value })}
                />
                <input
                  type="senha"
                  placeholder="Senha"
                  onChange={e => this.setState({ senha: e.target.value })}
                />
                <button type="submit">Entrar</button>
              </form> */}
            </Grid>
          </Typography>
        </Container>
      </React.Fragment>
    );
  }
}

export default withRouter(SignIn);
