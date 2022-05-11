import axios from 'axios'

export const getPositions = async () => {
  let positions = []

  try {
    let response = await axios.get('http://localhost:1028/api/positions/')
    console.log(response)
    if (!response.statusText == "OK")
      throw Error('No data available.')
      positions = response.data
  }
  catch (err) {
    console.log(err.message)
  }
  return positions
}

export const postPosition = async (position) => {
  await axios.post('http://localhost:1028/api/positions/', position)
    .then(response => console.log(response))
    .catch(error => console.log(error.message))
}

export const deletePosition = async (id) => {
  await axios.delete('http://localhost:1028/api/positions/' + id)
    .then(response => console.log(response))
    .catch(error => console.log(error.message))
}