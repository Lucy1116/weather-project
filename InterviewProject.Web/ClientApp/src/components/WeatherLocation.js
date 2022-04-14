import React, { Component } from 'react';

export class WeatherLocation extends Component {

    constructor(props) {
        super(props);
        this.state = {
            inputValue: "",
            locations: [],
            forecasts: [],
            locationLoading: false,
            weatherLoading: false
        };
    }

    searchLocation = () => {
        const { inputValue } = this.state;
        if (inputValue) {
            this.queryLocation(inputValue);
        }
    }

    handleLocationChange = (event) => {
        const selectedValue = event.target.value;
        this.queryWeather(selectedValue);
    }

    updateInputValue = (event) => {
        this.setState({ inputValue: event.target.value });
    }

    renderForecastsTable = () => {
        const { forecasts, weatherLoading } = this.state;
        if (weatherLoading) {
            return (<p><em>Weather Loading...</em></p>)
        };
        if (forecasts.length) {
            return (
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Temp. (C)</th>
                            <th>Temp. (F)</th>
                            <th>Humidity</th>
                            <th>predictability</th>
                        </tr>
                    </thead>
                    <tbody>
                        {forecasts.map(forecast =>
                            <tr key={forecast.id}>
                                <td>{forecast.applicable_Date}</td>
                                <td>{forecast.the_Temp}</td>
                                <td>{(forecast.the_Temp * 9) / 5 + 32}</td>
                                <td>{forecast.humidity}</td>
                                <td>{forecast.predictability}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            );
        }
    }

    renderLocationSelection = () => {
        const { locations, locationLoading } = this.state;

        if (locationLoading) {
            return (<p><em>Location Loading...</em></p>)
        };

        if (locations.length) {
            const options = locations.map((data) =>
                <option
                    key={data.woeid}
                    value={data.woeid}
                >
                    {data.title}
                </option>
            );

            return (
                <div>
                    <br />
                    <select onChange={this.handleLocationChange}>
                        <option>Select Item</option>
                        {options}
                    </select>
                </div>
            );
        }
    }


    render() {
        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast by location</h1>
                <br />
                <input
                    type="text"
                    placeholder="Enter Location"
                    required
                    value={this.state.inputValue}
                    onChange={this.updateInputValue}
                />
                <button className="btn btn-primary" onClick={this.searchLocation}>Search</button>

                {this.renderLocationSelection()}

                {this.renderForecastsTable()}
            </div>
        );
    }

    async queryLocation(cityName) {
        this.setState({ locations: [], locationLoading: true, forecasts: [] });
        const response = await fetch(`weatherLocation/location-search/${cityName}`);
        const data = await response.json();

        this.setState({ locations: data, locationLoading: false });
    }

    async queryWeather(cityId) {
        this.setState({ forecasts: [], weatherLoading: true });
        const response = await fetch(`weatherLocation/location-weather/${cityId}`);
        const data = await response.json();

        this.setState({ forecasts: data, weatherLoading: false });
    }
}
