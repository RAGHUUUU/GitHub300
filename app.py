from flask import Flask, render_template
import json
import os

app = Flask(__name__)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/privacy')
@app.route('/Home/Privacy')
def privacy():
    # Load employee data from sampledata.json
    json_path = os.path.join(os.path.dirname(__file__), 'sampledata.json')
    with open(json_path, 'r') as f:
        employees = json.load(f)
    return render_template('privacy.html', employees=employees)

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000, debug=True)
