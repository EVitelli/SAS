import { useState, useEffect } from "react";
import api from "../../services/api";

const loadingCategorias = async setCategorias => {
  let { results } = [];
  await api
    .get("/categorias")
    .then(response => {
      console.log(results);
      results = response.data;
    })
    .catch(erro => {
      console.log(erro);
    });

  setCategorias(results);
};

export function useCategorias() {
  const [categorias, setCategorias] = useState([]);

  useEffect(() => {
    loadingCategorias(setCategorias);
  }, []);

  return categorias;
}
